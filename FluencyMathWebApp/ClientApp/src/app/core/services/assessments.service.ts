import {Inject, Injectable} from "@angular/core";
import {HttpClient, HttpHeaders, HttpParams} from "@angular/common/http";
import {Observable} from "rxjs";
import {Problem} from "../models/problem.model";
//import { MatSnackBar } from "@angular/material/snack-bar";

const httpOptions = {
  headers: new HttpHeaders({
  'Content-Type': 'text/json',
  'Access-Control-Allow-Origin': '*',
  'Access-Control-Allow-Methods': '*',
  'Access-Control-Allow-Headers': 'Origin, X-Requested-With, Content-Type, Accept, Authorization'
  })
};

@Injectable({
  providedIn: 'root'
})
export class AssessmentsService {
  constructor(
    //private _snackBar: MatSnackBar,
    private httpClient: HttpClient,
    @Inject('API_BASE_URL') private apiBaseUrl: string,
    @Inject('EMPTY_ID') private empyId: string
  ){
  }

  get(): Observable<Problem[]> {
    return this.httpClient.get<Problem[]>(`${this.apiBaseUrl}assessment`);
  }

  //get(id: string): Observable<Problem> {
  //  return this.httpClient.get<Problem>(this.apiBaseUrl + 'assessments/' + id);
  //}

  //getByType(): Observable<Problem[]> {
  //  return this.httpClient.get<Problem[]>(`${this.apiBaseUrl}assessments`);
  //}

  save(assessment: Problem[]): Observable<Problem[]> {

    //this._snackBar.open("Candidate " + candidate.firstName + " " + candidate.lastName, "Saving", {
    //    duration: 2000,
    //  });

    return this.httpClient.post<Problem[]>(`${this.apiBaseUrl}assessment`, assessment, httpOptions)
      .pipe(
      
      );
  }
}
