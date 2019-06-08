            <h3>Status</h3>
            <form class="open_close_ticket"
                metal:use-macro="Views/Ticket/OpenCloseTicket/macros/open_close_control">
            <fieldset>
                <div class="form_element button">
                <p>This ticket is <span id="TicketState">open</span></p>
                <button id="CloseTicket">Close</button>
                </div>
            </fieldset>
            </form>
