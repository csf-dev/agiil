//@flow
import type { Observable } from 'rxjs';
import type { UiSwipe } from './UiSwipe';

export interface GetsUiSwipes {
    getUiSwipes() : Observable<UiSwipe>
}