import { Injectable } from '@angular/core';
import { ActivatedRoute, Data } from '@angular/router';

@Injectable()
export class UtilsService {
  constructor(private route: ActivatedRoute) {}

  getRouteData(): Data | undefined {
    let child = this.route.firstChild;
    while (child) {
      if (child.firstChild) {
        child = child.firstChild;
      } else if (child.snapshot.data ) {
        return child.snapshot.data;
      } else {
        return undefined;
      }
    }
    return undefined;
  }

  compareObjects(o1: any, o2: any): boolean {
    return o1?.id === o2?.id;
  }
}
