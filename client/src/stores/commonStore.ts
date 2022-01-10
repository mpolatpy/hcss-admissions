import { makeAutoObservable, runInAction } from "mobx";
import agent, { sleep } from "../api/agent";
import { School } from "../models/School";
import { SchoolYear } from "../models/SchoolYear";

export default class CommonStore {
    appLoaded = false;
    schoolYears: SchoolYear[] = [];
    schools: School[] = [];
    

    constructor() {
        makeAutoObservable(this);
    }

    setAppLoaded = () => {
        this.appLoaded = true;
    }

    get activeSchoolYear() {
        return this.schoolYears.find(x => x.isActiveYear)?.id;
    }

    loadInitialData = async () => {
        try{
            const schoolYears = await agent.SchoolYears.list();
            const schools = await agent.Schools.list();

            runInAction(() => {
                this.schoolYears = schoolYears;
                this.schools = schools;
            });
        } catch (e) {
            console.log(e);
        } finally {
            sleep(1000).then(() => this.setAppLoaded());
        }
    }
}