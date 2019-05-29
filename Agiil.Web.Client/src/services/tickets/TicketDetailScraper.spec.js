//@flow

describe('The ticket detail markup scraper', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    });

    afterEach(() => {
        if(root) root.remove();
    });

    it('should correctly parse a ticket ID', () => {

    });
});

function getSampleTicketMarkup() {
    return `<div class="page_area">
  <nav class="application_menu">
    <div>Application menu</div>
  </nav>
  <section class="content_area">
    <header>
      <div class="ticket_identity">
        <span class="screen_reader_only">Ticket reference</span>
        <strong class="ticket_reference">CC456</strong>:
        <span class="ticket_type">Story</span>
      </div>
      <h1 class="title_content">This is the title for the ticket</h1>
    </header>
    <div class="content_container">
      <div class="main_content">
        <section class="ticket_description">
          <header><h2 class="screen_reader_only">Ticket description</h2></header>
          <div class="markdown_rendered_text description_content">
            This is the <strong>markdown-rendered</strong> ticket description HTML.
          </div>
        </section>
        <section class="ticket_comments">
          <header><h2>Ticket comments</h2></header>
          <ol class="comment_list"></ol>
          <form class="add_a_comment"
                id="new_comment"
                action="Comment/Add" method="post">
            <fieldset>
              <input type="hidden" name="TicketId" value="0" />
              <div class="form_element field long_text">
                <label for="AddCommentBody">Body</label>
                <textarea id="AddCommentBody" name="Body">This is the body of the comment to be added</textarea>
              </div>
              <div class="form_element feedback warning AddCommentFeedbackMessage">
                <p>Please enter a comment.</p>
              </div>
              <div class="form_element button">
                <button id="AddCommentSubmit">Submit</button>
              </div>
            </fieldset>
          </form>
        </section>
      </div>
      <aside class="main_content_asides">
        <header><h2>Ticket properties</h2></header>
        <h3>Status</h3>
        <form class="open_close_ticket"
              action="OpenCloseTicket/Close/0"
              method="POST">
          <fieldset>
            <div class="form_element">
              <p>
                <span class="screen_reader_only">This ticket is</span>
                <span class="ticket_state">Closed</span><span class="screen_reader_only">.</span>
                <button id="OpenCloseButton">Re-open</button>
              </p>
            </div>
          </fieldset>
        </form>
        <h3>Edit</h3>
        <p>
          <a href="Ticket/Edit/0" id="EditTicketLink">Edit this ticket</a>
        </p>
        <h3>Sprint</h3>
        <p>
          <span class="screen_reader_only">This ticket is part of</span>
          <a href="Sprint/Index/0"><strong class="TicketSprintName">Sprint 66</strong></a>
        </p>
        <h3>Labels</h3>
        <ul class="ticket_labels">
          <li>
            <a href="Label/Index/labelOne"><span class="name">Label One</span></a>
          </li>
          <li>
            <a href="Label/Index/labelTwo"><span class="name">Label Two</span></a>
          </li>
        </ul>
        <h2>Story point estimate</h2>
        <p class="story_point_estimate">
          <span class="value">3</span>
          story <span>points</span>
        </p>
        <h3>Work log</h3>
        <p class="total_work_logged">
          <span class="total_minutes">30</span> minutes of work logged
        </p>
        <p>
          <a href="AddTicketWorkLog/Index/0">Log work</a>
        </p>
        <h3>Related tickets</h3>
        <ul class="related_tickets">
          <li>
            <header>
              <span class="relationship_summary">Relates to</span>
            </header>
            <div>
              <a href="Ticket/1"
                 class="ticket_title">
                This is the related ticket
              </a>
              <a href="Ticket/1"
                 class="ticket_reference">
                #AB123
              </a>
            </div>
          </li>
        </ul>
        <h3>Created</h3>
        <p>
          Created by
          <strong id="TicketCreatorUsername">username</strong>
          on
          <strong>2001-01-01 19:21:22</strong>
        </p>
      </aside>
    </div>
  </section>
</div>
`;
}