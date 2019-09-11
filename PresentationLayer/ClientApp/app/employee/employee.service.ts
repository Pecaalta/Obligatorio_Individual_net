import { Injectable } from '@angular/core';

/**
 * Service for notify and subscribe to events.
 */
@Injectable()
export class EmployeeService {
    constructor() {
        console.log('constructor');
    }

    public addEmployee() {
        console.log('add employee');
    }

    public editEmployee() {
        console.log('edit employee');
    }

    public getEmployees() {
        console.log('Get employees');
    }
}
