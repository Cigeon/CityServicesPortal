import { Component } from '@angular/core';

@Component({
    selector: 'counter',
    templateUrl: './counter.component.html'
})
export class CounterComponent {
    public currentCount = 0;

    model = {
        left: true,
        middle: false,
        right: false
    };

    public incrementCounter() {
        this.currentCount++;
    }
}
