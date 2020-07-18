//@flow
import 'scss/TicketList.scss';

// This is a bit of an oddity that the label-detail page imports the ticket-list styles.
// I think that's because the label detail page is mainly comprised of a ticket list component.
// But in that case the styles for listing tickets should be split into a component SCSS file.