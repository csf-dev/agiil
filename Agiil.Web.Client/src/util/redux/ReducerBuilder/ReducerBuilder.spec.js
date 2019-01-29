//@flow
import type { Reducer } from 'redux';
import { buildObjectReducer, buildPrimitiveReducer } from '.';
import type { Action, AnyAction } from '../../../Action';

type MyBaz = {| wing : boolean, wang : number, wong : Array<number> |};
type MyState = {| foo : string, bar : number, baz : MyBaz |};

const MyStateFoo : 'FOO' = 'FOO';
const MyStateBar : 'BAR' = 'BAR';
const IncrementMyBazWang : 'INC_WANG' = 'INC_WANG';
const IncrementNumber : 'INC' = 'INC';
const SetNumber : 'SET' = 'SET';

type MyStateFooAction = Action<typeof MyStateFoo> & { foo : string };
type MyStateBarAction = Action<typeof MyStateBar> & { bar : number };
type IncrementMyBazWangAction = Action<typeof IncrementMyBazWang> & { incrementBy : number };
type IncrementNumberAction = Action<typeof IncrementNumber> & { incrementBy : number };
type SetNumberAction = Action<typeof SetNumber> & { val : number };

const reduceMyStateFoo = (state : ?MyState, action : MyStateFooAction) => ({...state, foo: action.foo});
const reduceMyStateBar = (state : ?MyState, action : MyStateBarAction) => ({...state, bar: action.bar});
const reduceMyStateBaz = (state : ?MyBaz, action : IncrementMyBazWangAction) => {
    const val = state? state.wang : 0;
    return {
        ...state,
        wang: val + action.incrementBy
    };
};

describe('The reducer builder', () => {
    describe('in Object mode', () => {
        let defaultState : MyState;
        let reducer : Reducer<MyState,AnyAction>;

        beforeEach(() => {
            defaultState = {
                foo: 'Foo',
                bar: 5,
                baz: {
                    wing: true,
                    wang: 42,
                    wong: []
                }
            };

            reducer = buildObjectReducer<MyState>(defaultState)
                .forTypeKey(MyStateFoo).andAction<MyStateFooAction>(reduceMyStateFoo)
                .forTypeKey(MyStateBar).andAction<MyStateBarAction>(reduceMyStateBar)
                .forChild('baz').andReducer(reduceMyStateBaz)
                .build();
        });

        it('should be able to set the state of a string property', () => {
            const state = defaultState;

            const result = reducer(state, { type: MyStateFoo, foo: 'New value' });

            expect(result.bar).toBe(5);
            expect(result.baz).toBe(defaultState.baz);
            expect(result.foo).toBe('New value');
        });

        it('should be able to set the state of a numeric property', () => {
            const state = defaultState;

            const result = reducer(state, { type: MyStateBar, bar: 22 });

            expect(result.bar).toBe(22);
            expect(result.baz).toBe(defaultState.baz);
            expect(result.foo).toBe('Foo');
        });

        it('should be able to operate upon a child object', () => {
            const state = defaultState;

            const result = reducer(state, { type: IncrementMyBazWang, incrementBy: 6 });

            expect(result.bar).toBe(5);
            expect(result.baz.wang).toBe(48);
            expect(result.foo).toBe('Foo');
        });
    });

    describe('in primitive mode', () => {
        let reducer : Reducer<number,AnyAction>;

        beforeEach(() => {
            reducer = buildPrimitiveReducer<number>(5)
                .forTypeKey(IncrementNumber).andAction<IncrementNumberAction>((s, a) => s + a.incrementBy)
                .forTypeKey(SetNumber).andAction<SetNumberAction>((s, a) => a.val)
                .build();
        });

        it('should be able to increment a number', () => {
            const result = reducer(undefined, { type: IncrementNumber, incrementBy: -3 });
            expect(result).toBe(2);
        });

        it('should be able to increment a number', () => {
            const result = reducer(undefined, { type: SetNumber, val: 16 });
            expect(result).toBe(16);
        });
    });
});

