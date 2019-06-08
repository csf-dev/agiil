            <h3>Sprint</h3>
            <p tal:condition="ticket/Sprint">
            <span class="screen_reader_only">This ticket is part of</span>
            <a href="Sprint/Index/0"
                tal:define="url string:Sprint/Index/${ticket/Sprint/Id}"
                tal:attributes="href url"><strong tal:content="ticket/Sprint/Name"
                                                class="TicketSprintName">Sprint name</strong></a>
            </p>
            <p tal:condition="not:ticket/Sprint">
            This ticket is not part of any sprint
            </p>
