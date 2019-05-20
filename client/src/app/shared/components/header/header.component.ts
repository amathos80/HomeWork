import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'hw-header',
  templateUrl: './header.component.html',
  styles: []
})
export class HeaderComponent implements OnInit {
  @Input() buttonLabel = '';
  @Input() buttonLink = '#';
  @Input() buttonType: 'btn-link' | 'btn-primary' = 'btn-link';
  @Input() title = '';  

  constructor() { }

  ngOnInit() {
  }

}
