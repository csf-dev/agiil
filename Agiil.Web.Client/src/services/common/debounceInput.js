//@flow
import { debounceTime } from 'rxjs/operators';

const timeMilliseconds = 500;
export function debounceInput<T>() : rxjs$MonoTypeOperatorFunction<T> {
    return debounceTime<T>(timeMilliseconds);
}