//@flow
import { getTestDom, testDomId } from 'util/TestDom';
import { TicketCommentsScraper } from './TicketCommentsScraper';
import type { TicketReference } from 'models/tickets/TicketReference';


describe('The ticket comment markup scraper', () => {
    let root : HTMLDivElement;

    beforeEach(() => {
        root = getTestDom(); 
    });

    afterEach(() => {
        if(root) root.remove();
    });

    it('should be able to read three comments', () => {
        root.innerHTML = getSampleCommentsMarkup();
        const sut = new TicketCommentsScraper();
        const result = sut.getTicketComments({reference : 'AA1'});

        expect(result.length).toBe(3);
    });

    describe('and the first comment', () => {
        it('should have the correct author', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[0]?.author).toBe('user1');
        });

        it('should have the correct timestamp', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[0]?.createdTimestamp).toBe('2001-01-01 19:21:22');
        });

        it('should have the correct comment markup', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[0]?.commentMarkup).toBe('This some <strong>comment test</strong> which is rendered with markdown.');
        });

        it('should have the correct ID', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[0]?.id).toBe(1);
        });
    })

    describe('and the second comment', () => {
        it('should have the correct author', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[1]?.author).toBe('user2');
        });

        it('should have the correct timestamp', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[1]?.createdTimestamp).toBe('2001-01-02 19:21:22');
        });

        it('should have the correct comment markup', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[1]?.commentMarkup).toBe('This some <em>different</em> comment text.');
        });

        it('should have the correct ID', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[1]?.id).toBe(2);
        });
    });

    describe('and the third comment, which was created by a different user', () => {
        it('should have the correct author', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[2]?.author).toBe('user3');
        });

        it('should have the correct timestamp', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[2]?.createdTimestamp).toBe('2001-01-03 19:21:22');
        });

        it('should have the correct comment markup', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[2]?.commentMarkup).toBe('This some <em>even more different</em> comment text.');
        });

        it('should have no ID', () => {
            root.innerHTML = getSampleCommentsMarkup();
            const sut = new TicketCommentsScraper();
            const result = sut.getTicketComments({reference : 'AA1'});

            expect(result[2]?.id).toBe(0);
        });
    });
});

function getSampleCommentsMarkup() {
    return `<div class="page_area">
  <nav class="application_menu">
    <div>Application menu</div>
  </nav>
  <section class="content_area">
    <header>
      <div class="ticket_identity">
        <span class="screen_reader_only">Ticket reference</span>
        <strong class="ticket_reference">AB123</strong>:
        <span class="ticket_type">Thing</span>
      </div>
      <h1 class="title_content">Ticket title</h1>
    </header>
    <div class="content_container">
      <div class="main_content">
        <section class="ticket_description">
          <header><h2 class="screen_reader_only">Ticket description</h2></header>
          <div class="markdown_rendered_text description_content">Ticket description here.</div>
        </section>
        <section class="ticket_comments">
          <ol class="comment_list">
            <li>
                <header>
                <p>
                    Written by <strong class="author_name">user1</strong> on
                    <strong class="author_timestamp">2001-01-01 19:21:22</strong>.
                </p>
                <p>
                    <a href="Comment/Edit/1" class="edit_comment">Edit this comment</a>
                </p>
                <form method="post" action="Comment/ConfirmDelete" >
                    <fieldset>
                    <input type="hidden" name="id" value="1" />
                    <button class="delete_comment">Delete this comment</button>
                    </fieldset>
                </form>
                </header>
                <div class="comment_content markdown_rendered_text">This some <strong>comment test</strong> which is rendered with markdown.</div>
            </li>
            <li>
                <header>
                <p>
                    Written by <strong class="author_name">user2</strong> on
                    <strong class="author_timestamp">2001-01-02 19:21:22</strong>.
                </p>
                <p>
                    <a href="Comment/Edit/2" class="edit_comment">Edit this comment</a>
                </p>
                <form method="post" action="Comment/ConfirmDelete" >
                    <fieldset>
                    <input type="hidden" name="id" value="2" />
                    <button class="delete_comment">Delete this comment</button>
                    </fieldset>
                </form>
                </header>
                <div class="comment_content markdown_rendered_text">This some <em>different</em> comment text.</div>
            </li>
            <li>
                <header>
                <p>
                    Written by <strong class="author_name">user3</strong> on
                    <strong class="author_timestamp">2001-01-03 19:21:22</strong>.
                </p>
                </header>
                <div class="comment_content markdown_rendered_text">This some <em>even more different</em> comment text.</div>
            </li>
          </ol>
        </section>
      </div>
    </div>
  </section>
</div>`;
}
