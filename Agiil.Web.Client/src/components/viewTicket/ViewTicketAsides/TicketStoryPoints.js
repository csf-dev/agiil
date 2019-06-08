            <h2>Story point estimate</h2>
            <p tal:condition="ticket/HasStoryPoints"
            tal:define="multiplePoints csharp:ticket.StoryPoints &gt; 1;
                        pointOrPoints csharp:multiplePoints? &quot;points&quot; : &quot;point&quot;"
            class="story_point_estimate">
            <span tal:content="ticket/StoryPoints" class="value">3</span>
            story <span tal:replace="pointOrPoints">points</span>
            </p>
            <p tal:condition="not:ticket/HasStoryPoints"
            class="story_point_estimate no_estimate">
            No story point estimate
            </p>
