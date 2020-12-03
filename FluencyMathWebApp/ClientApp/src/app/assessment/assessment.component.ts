import { Component, Inject } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { AssessmentsService } from '../core/services/assessments.service';

@Component({
  selector: 'app-assessment',
  templateUrl: './assessment.component.html'
})
export class AssessmentComponent {

  public assessment: Problem[];
  public currentProblem: Problem;
  public startScreen: boolean;
  public endScreen: boolean;
  public problemIndex = 0;
  public countdown = '';

 assessmentForm = new FormGroup({
   answer: new FormControl('')
  });


  public nextProblem() {
    this.problemIndex++;
  }

  public loadProblem() {

    this.clear();
    console.log(this.problemIndex);
    console.log(this.currentProblem);

    //2 checks, do we have more then 0 problems?
    //are we on the last problem?
    if (this.assessment.length >= 0 && this.problemIndex <= this.assessment.length - 1) {
      
    }

    let saved = this.saveAssessment();

    let problem = this.assessment[this.problemIndex];
    this.currentProblem = problem;



    this.limitAnswerScope();

    this.nextProblem();

  }

  public limitAnswerScope() {

    var values = this.currentProblem.values;
    var maxLength = 0;
    values.forEach(this.getDigitCount);
  }

  public displayCountdown(displayValue, my) {
    my.countdown = String(displayValue);

    if (displayValue == '')
      my.loadProblem();
  }

  public startAssessment() {

    this.countdown = 'Ready!';
    setTimeout(this.displayCountdown, 2000, '3', this);
    setTimeout(this.displayCountdown, 3000, '2', this);
    setTimeout(this.displayCountdown, 4000, '1', this);
    setTimeout(this.displayCountdown, 5000, '', this);
  }

  public clear() {
    this.assessmentForm.get('answer').setValue('');

  }

  public getDigitCount(value) {
    var stringValue = String(value)
    console.log(stringValue.length);
  }

  public keypadPress(keyValue) {

    var currentValue = this.assessmentForm.get('answer').value
    this.assessmentForm.get('answer').setValue(currentValue + keyValue);

  }

  bindAssessment(assessment) {
    this.assessment = assessment;
  }

  constructor(private assessmentsService: AssessmentsService) {

    this.startScreen = true;
    this.endScreen = false;
    this.assessmentsService.get().subscribe(assessment => this.bindAssessment(assessment));

  }

  saveAssessment() {
    console.log("saving assessment", this.assessment);
    this.assessmentsService.save(this.assessment).subscribe(() => "", _ => "");
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
