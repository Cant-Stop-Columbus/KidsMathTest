import { Component, Inject } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html'
})
export class AssessmentComponent {

  public assessment: Problem[];
  public currentProblem: Problem;
  public problemIndex = 0;

  public nextProblem() {
    this.problemIndex++;
  }

  public loadProblem() {

    console.log(this.problemIndex);
    console.log(this.currentProblem);

    //2 checks, do we have more then 0 problems?
    //are we on the last problem?
    //if (this.assessment.length >= 0 && cu)

    let problem = this.assessment[this.problemIndex];
    this.currentProblem = problem;

    this.nextProblem();

  }


  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    let headerConfig = new HttpHeaders()
      .set('Content-Type', 'text/json')
      .set('Access-Control-Allow-Origin', '*')
      .set('Access-Control-Allow-Methods', '*')
      .set('Access-Control-Allow-Headers', 'Origin, X-Requested-With, Content-Type, Accept, Authorization');

    http.get<Problem[]>('https://localhost:44327/api/test', { headers: headerConfig }).subscribe(result => {
      this.assessment = result;
      console.log("did this work", result);
    }, error => console.error(error));




  }
}

interface Problem {
  values: number[];
  method: string;
  solution: number;
  result: boolean;
  remainder: number;
}

//We can add a module later that will handle all our http calls and dothe header config work
/*import * as lskeys from './../localstorage.items';
import { Observable } from 'rxjs/Observable';
import { Injectable } from '@angular/core';
import { HttpEvent, HttpInterceptor, HttpHandler, HttpRequest, HttpHeaders } from '@angular/common/http';

@Injectable()
export class HeaderInterceptor implements HttpInterceptor {

    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        if (true) { // e.g. if token exists, otherwise use incomming request.
            return next.handle(req.clone({
                setHeaders: {
                    'AuthenticationToken': localStorage.getItem('TOKEN'),
                    'Tenant': localStorage.getItem('TENANT')
                }
            }));
        }
        else {
            return next.handle(req);
        }
    }
}*/
