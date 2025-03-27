import { makeAutoObservable } from "mobx";
import { ActivityHistoryDTO } from "../types";

class ActivityStore {
    activityHistory: ActivityHistoryDTO[] = [];

    constructor() {
        makeAutoObservable(this);
    }
}
export const activityStore = new ActivityStore();
