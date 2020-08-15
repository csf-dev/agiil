//@flow
import * as React from "react";
import type { PanelName } from "./PanelName";
import { NavigationPanel, MainPanel, AsidesPanel } from "./PanelName";
import { getElementsHtml } from 'util/dom';
import type { HasChildren } from 'components';
import type { Observable, Subscription } from 'rxjs';
import { getUiSwipes, swipeDirections } from 'services/domEvents';
import type { UiSwipe } from 'services/domEvents';

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
            swipes = getUiSwipes(element);

        this.#swipeSubscription = swipes.subscribe((swipe : UiSwipe) => {
            if(swipe.direction == swipeDirections.left)
                this.props.onSwipeLeft();
            
            if(swipe.direction == swipeDirections.right)
                this.props.onSwipeRight();
        });
    }
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
