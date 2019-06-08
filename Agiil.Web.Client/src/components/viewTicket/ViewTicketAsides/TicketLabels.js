            <h3>Labels</h3>
            <ul class="ticket_labels" tal:condition="ticket/HasLabels">
            <li tal:repeat="label ticket/Labels">
                <a href="Label/Index/label+name"
                tal:define="encodedName label/UrlEncodedName;
                            url string:Label/Index/$encodedName"
                tal:attributes="href url"><span class="name" tal:content="label/Name">Label name</span></a>
            </li>
            </ul>
            <p tal:condition="not:ticket/HasLabels">
            This ticket has no labels
            </p>
