//@flow

export class Timespan {
    hours : number;
    minutes : number;
    seconds : number;

    get totalHours() {
        return this.hours + getHigherOrderTime(this.minutes) + getHigherOrderTime(getHigherOrderTime(this.seconds));
    }

    get totalMinutes() {
        return this.minutes + getHigherOrderTime(this.seconds) + getLowerOrderTime(this.hours);
    }

    get totalSeconds() {
        return this.seconds + getLowerOrderTime(this.minutes) + getLowerOrderTime(getLowerOrderTime(this.hours));
    }

    constructor(hours : number, minutes : number, seconds : number) {
        this.hours = hours;
        this.minutes = minutes;
        this.seconds = seconds;
    }
}

function getHigherOrderTime(lowerOrder : number) : number {
    return lowerOrder / 60;
}

function getLowerOrderTime(higherOrder : number) : number {
    return higherOrder * 60;
}

export function parseTimespan(timeHoursMinutesSeconds : string) : ?Timespan {
    const matches = [...getPatternMatches(timeHoursMinutesSeconds)];
    return getTimespan(matches);
}

function* getPatternMatches(timeHoursMinutesSeconds : string) : Iterable<string> {
    const hoursMinsSecsPattern = /:?(\d{1,7}){1,3}/g;
    let timeMatch;
    while((timeMatch = hoursMinsSecsPattern.exec(timeHoursMinutesSeconds)) != null) {
        // The while statement above ensures that timeMatch cannot be null, yet
        // FlowJS thinks it could be here
        // $FlowFixMe
        yield timeMatch[1];
    }
}

function getTimespan(timeMatches : Array<string>) : ?Timespan {
    switch(timeMatches.length) {
    case 3:
        return new Timespan(parseInt(timeMatches[0]), parseInt(timeMatches[1]), parseInt(timeMatches[2]));
    case 2:
        return new Timespan(0, parseInt(timeMatches[0]), parseInt(timeMatches[1]));
    case 1:
        return new Timespan(0, 0, parseInt(timeMatches[0]));
    default:
        return null;
    }
}