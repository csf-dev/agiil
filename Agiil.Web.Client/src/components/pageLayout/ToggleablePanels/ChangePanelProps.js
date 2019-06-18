//@flow
import type { ActivePagePanel } from 'models/pageLayout';

const Left : 'Left' = 'Left', Right : 'Right' = 'Right';
export { Left, Right };

export type MoveLeft = typeof(Left);
export type MoveRight = typeof(Right);
export type MovePanelType = MoveLeft | MoveRight;

export type ChangePanelProps = ActivePagePanel & {
    type : MovePanelType,
    enabled : bool,
    onClick : () => void
};