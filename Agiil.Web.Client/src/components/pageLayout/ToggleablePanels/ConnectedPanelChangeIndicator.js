//@flow
import { connect } from 'react-redux';
import type { ActivePagePanel } from 'models/pageLayout';
import type { PanelChangeIndicatorProps } from './PanelChangeIndicator';
import { PanelChangeIndicator } from './PanelChangeIndicator';

function mapStateToProps(state : { activePagePanel : ActivePagePanel }) : PanelChangeIndicatorProps {
    return {
        currentPanel: state?.activePagePanel?.activePanel,
        recentlyChanged: state?.activePagePanel?.recentlyChanged,
    };
}

const connectedPanelChangeIndicator = connect<PanelChangeIndicatorProps, any, any, any, any, any>(
    mapStateToProps
)(PanelChangeIndicator);
export { connectedPanelChangeIndicator };