//@flow
import { TicketDetailFromServerStateProvider } from './TicketDetailFromServerStateProvider';

describe('The ticket detail provider which reads server state', () => {
    it('should not return null when provided with just an ID, reference and type', () => {
        const minimalValidState = {
            Id: 5,
            Reference: 'AB123',
            Type: { Name: 'Ticket' }
        };
        const sut = new TicketDetailFromServerStateProvider(minimalValidState);

        const result = sut.getTicketDetail();

        expect(result).not.toBeFalsy();
    });

    it('should correctly read the ticket ID', () => {
        const minimalValidState = {
            Id: 5,
            Reference: 'AB123',
            Type: { Name: 'Ticket' }
        };
        const sut = new TicketDetailFromServerStateProvider(minimalValidState);
        
        const result = sut.getTicketDetail();

        expect(result?.id).toBe(5);
    });

    it('should correctly read the ticket reference', () => {
        const minimalValidState = {
            Id: 5,
            Reference: 'AB123',
            Type: { Name: 'Ticket' }
        };
        const sut = new TicketDetailFromServerStateProvider(minimalValidState);
        
        const result = sut.getTicketDetail();

        expect(result?.reference).toBe('AB123');
    });

    it('should correctly read the ticket type', () => {
        const minimalValidState = {
            Id: 5,
            Reference: 'AB123',
            Type: { Name: 'Ticket' }
        };
        const sut = new TicketDetailFromServerStateProvider(minimalValidState);
        
        const result = sut.getTicketDetail();

        expect(result?.type).toBe('Ticket');
    });
});