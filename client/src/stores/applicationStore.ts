import { makeAutoObservable } from "mobx";

export default class ApplicationStore {

    constructor(){
        makeAutoObservable(this)
    }
}