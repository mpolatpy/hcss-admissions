import { makeAutoObservable, runInAction } from "mobx";
import agent, { sleep } from "../api/agent";
import { SchoolYear } from "../models/SchoolYear";

export default class CommonStore {
    appLoaded = false;
    schoolYears: SchoolYear[] = [];

    constructor() {
        makeAutoObservable(this);
    }

    setAppLoaded = () => {
        this.appLoaded = true;
    }

    loadInitialData = async () => {
        try{
            const schoolYears = await agent.SchoolYears.list();
            runInAction(() => {
                this.schoolYears = schoolYears;
            })
        } catch (e) {
            console.log(e);
        } finally {
            sleep(1000).then(() => this.setAppLoaded());
        }
    }
}