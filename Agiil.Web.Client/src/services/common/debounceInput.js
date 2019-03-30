//@flow
import { debounceTime } from 'rxjs/operators';

const timeMilliseconds = 500;
export const debounceInput = () => debounceTime(timeMilliseconds);