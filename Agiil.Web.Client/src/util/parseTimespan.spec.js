//@flow
import { parseTimespan, Timespan } from './parseTimespan';

describe('The timespan parser', () => {
    it('should be able to parse 1 hour, 1 minute and 1 second', () => {
        const result = parseTimespan('01:01:01');
        expect(result).toEqual(new Timespan(1, 1, 1));
    });

    it('should be able to parse 5 hours, 42 minutes and 12 seconds', () => {
        const result = parseTimespan('05:42:12');
        expect(result).toEqual(new Timespan(5, 42, 12));
    });

    it('should be able to parse 5 hours without a leading zero', () => {
        const result = parseTimespan('5:0:0');
        expect(result).toEqual(new Timespan(5, 0, 0));
    });

    it('should be able to parse 10 minutes without an hours component', () => {
        const result = parseTimespan('10:00');
        expect(result).toEqual(new Timespan(0, 10, 0));
    });

    it('should be able to parse 90 minutes without an hours component', () => {
        const result = parseTimespan('90:00');
        expect(result).toEqual(new Timespan(0, 90, 0));
    });
});

describe('The timespan object', () => {
    it('should be able to get a total amount of hours equal to 90 minutes', () => {
        const sut = new Timespan(1, 30, 0);
        expect(sut.totalHours).toBe(1.5);
    });

    it('should be able to get a total amount of minutes equal to 90.5 minutes', () => {
        const sut = new Timespan(1, 30, 30);
        expect(sut.totalMinutes).toBe(90.5);
    });

    it('should be able to get a total amount of seconds equal to 3665 seconds', () => {
        const sut = new Timespan(1, 1, 5);
        expect(sut.totalSeconds).toBe(3665);
    });
});