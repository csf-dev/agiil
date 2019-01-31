//@flow
import { v4 as uuid } from 'uuid';

const getId : () => string = () => uuid();
export default getId;