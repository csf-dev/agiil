            <h3>Work log</h3>
            <p tal:condition="ticket/HasWorkLogged"
            class="total_work_logged">
            <span tal:content="ticket/TotalWorkLogged/TotalMinutes" class="total_minutes">30</span> minutes of work logged
            </p>
            <p tal:condition="not:ticket/HasWorkLogged"
            class="total_work_logged nothing_logged">
            No work logged
            </p>
            <p tal:define="url string:AddTicketWorkLog/Index/${ticket/Reference}">
            <a href="AddTicketWorkLog/Index/0" tal:attributes="href url">Log work</a>
            </p>
