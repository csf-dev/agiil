//@flow
import * as React from "react";
import type { PanelName } from "./PanelName";
import { NavigationPanel, MainPanel, AsidesPanel } from "./PanelName";
import { getElementsHtml } from 'util/dom';
import type { HasChildren } from 'components';
import type { Observable, Subscription } from 'rxjs';
import { getSwipes } from 'services/domEvents';
import type { Swipe } from 'services/domEvents';

export type PanelContainerProps = {
    currentPanel : ?PanelName,
    recentlyChanged : bool,
    onSwipeLeft : () => void,
    onSwipeRight : () => void,
} & HasChildren;

export class PanelContainer extends React.Component<PanelContainerProps> {
    #ref : { current: null | HTMLDivElement };
    #swipeSubscription : ?Subscription;

    constructor(props : PanelContainerProps) {
        super(props);
        this.#ref = React.createRef<HTMLDivElement>();
    }

    render() {
        return (
            <div className={getClassName(this.props.currentPanel, this.props.recentlyChanged)} ref={this.#ref}>
                {this.props.children}
            </div>
        );
    }

    componentDidMount() {
        this.setupSwipeEvents();
    }

    setupSwipeEvents() {
        if(!this.#ref.current) {
            if(this.#swipeSubscription)
                this.#swipeSubscription.unsubscribe();
            
            return;
        }

        const
            element = this.#ref.current,
            swipes = getSwipes(element);

        this.#swipeSubscription = swipes.subscribe((swipe : Swipe) => {
            if(isSwipeLeft(swipe)) this.props.onSwipeLeft();
            if(isSwipeRight(swipe)) this.props.onSwipeRight();
        });
    }
}

function isSwipeLeft(swipe : Swipe) : bool {
    if(!isHorizontalSwipe(swipe)) return false;
    return swipe.vector.x < 0;
}

function isSwipeRight(swipe : Swipe) : bool {
    if(!isHorizontalSwipe(swipe)) return false;
    return swipe.vector.x > 0;
}

function isHorizontalSwipe(swipe : Swipe) : bool {
    const absoluteHorizDistance = Math.abs(swipe.vector.x);
    if(isNaN(absoluteHorizDistance) || absoluteHorizDistance < 150) return false;

    if(isNaN(swipe.velocity) || swipe.velocity < 0.2) return false;

    const horizToVertRatio = Math.abs(swipe.vector.x) / Math.abs(swipe.vector.y);
    if(isNaN(horizToVertRatio) || horizToVertRatio < 2) return false;

    return true;
}

const
    pageAreaClass = 'page_area',
    navPanelActiveClass = 'app_nav_panel_active',
    asidesPanelActiveClass = 'asides_panel_active',
    mainPanelActiveClass = '';

function getClassName(currentPanel : ?PanelName, recentlyChanged : bool) {
    const classes = [pageAreaClass];

    switch(currentPanel)
    {
    case NavigationPanel:
        classes.push(navPanelActiveClass);
        break;
    case MainPanel:
        classes.push(mainPanelActiveClass);
        break;
    case AsidesPanel:
        classes.push(asidesPanelActiveClass);
        break;
    }

    if(recentlyChanged) classes.push('recently_changed');

    return classes.join(' ');
}
