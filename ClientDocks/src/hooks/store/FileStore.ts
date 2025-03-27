import { makeAutoObservable } from "mobx";
import { FileDTO } from "../../api/client";

class FileStore {
    files: FileDTO[] = [];

    constructor() {
        makeAutoObservable(this);
    }
}
