//@flow
import type { Action, ComponentId } from 'models';

export const
    ChangeComponentTextValue : 'CHANGE_COMPONENT_TEXT_VALUE' = 'CHANGE_COMPONENT_TEXT_VALUE';

export type ChangeComponentTextValueAction = Action<typeof ChangeComponentTextValue,{value: string},ComponentId>;

export function updateComponentTextValue(value : string, componentId : string) : ChangeComponentTextValueAction {
    return { type: ChangeComponentTextValue, payload: { value }, meta: { componentId } };
}
