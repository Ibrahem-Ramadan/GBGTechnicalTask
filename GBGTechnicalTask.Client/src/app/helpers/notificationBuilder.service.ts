import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TranslationService } from './translation.service';



@Injectable()
export class NotificationBuilderService {

  constructor(private toastr: ToastrService, private translationService: TranslationService )
      {

      }

      showSuccess(message: string) {
        // this.toastr.success(this.translationService.translateText(message), 'Success!');
        this.toastr.success(message, 'Success!');

      }

      showError(message: string) {
        this.toastr.error(message, 'Oops!');
      }

      showWarning(message: string) {
        this.toastr.warning(message, 'Alert!');
      }

      showInfo(message: string) {
        this.toastr.info(message, 'Info!' );
      }

}
