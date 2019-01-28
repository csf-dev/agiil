//@flow
import type { Reducer } from 'redux';
import type { BuildsObjectReducer, BuildsReducer } from './BuildsReducer';
import { ObjectReducerBuilder } from './ReducerBuilder';
import type { AnyAction, Action } from '../../../Action';

describe('The reducer builder', () => {
    describe('in Object mode', () => {
        it('should accept the correct types', () => {
            const mockedBuilder = new ObjectReducerBuilder<MyState>();
            spyOn(mockedBuilder, 'forActionType').and.returnValue(mockedBuilder);
            spyOn(mockedBuilder, 'withChild').and.returnValue(mockedBuilder);
            spyOn(mockedBuilder, 'build').and.returnValue((x) => x);

            const builder : BuildsObjectReducer<MyState> = mockedBuilder;
            const reducer : Reducer<MyState,AnyAction> = builder
                .forTypeKey(MyStateFoo).andAction<MyStateFooAction>(reduceMyStateFoo)
                .forTypeKey(MyStateBar).andAction<MyStateBarAction>(reduceMyStateBar)
                .forChild('baz').andReducer(reduceMyStateBaz)
                .build();
            
            // This isn't a true test of functionality.
            // Instead it's a proof that the FlowJS type system understands the
            // builder, hence the meaningless assertion here.
            // If there is a problem, FlowJS would have already complained with
            // an error of its own.
            expect(1).toBe(1);
        })
    });
});

type MyBaz = {| wing : boolean, wang : number, wong : Array<number> |};
type MyState = {| foo : string, bar : number, baz : MyBaz |};

const state : MyState = {
    foo: 'Foo',
    bar: 5,
    baz: {
        wing: true,
        wang: 42,
        wong: []
    }
}

const MyStateFoo : 'FOO' = 'FOO';
const MyStateBar : 'BAR' = 'BAR';
const IncrementMyBazWang : 'INC_WANG' = 'INC_WANG';

type MyStateFooAction = Action<typeof MyStateFoo> & { foo : string };
type MyStateBarAction = Action<typeof MyStateBar> & { bar : number };
type IncrementMyBazWangAction = Action<typeof IncrementMyBazWang> & { incrementBy : number };

const reduceMyStateFoo = (state : ?MyState, action : MyStateFooAction) => ({...state, foo: action.foo});
const reduceMyStateBar = (state : ?MyState, action : MyStateBarAction) => ({...state, bar: action.bar});
const reduceMyStateBaz = (state : ?MyBaz, action : IncrementMyBazWangAction) => {
    const wang = state? state.wang : 0;
    return {
        ...state,
        wang: wang + action.incrementBy
    };
};
