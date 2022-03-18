import { Component } from '@angular/core';
import { TranslateService } from '@ngx-translate/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  constructor(private readonly _translateService: TranslateService) {
    _translateService.setDefaultLang("en");
    _translateService.use(localStorage.getItem("currentLanguage") || "en");
  }
  title = 'FacilityManagement.App';
}
