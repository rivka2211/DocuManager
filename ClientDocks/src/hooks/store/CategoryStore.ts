import { makeAutoObservable } from "mobx";
import { CategoryDTO } from "../../api/client";


class CategoryStore {
    categories: CategoryDTO[] = [];
    
    constructor() {
        makeAutoObservable(this);
    }
}
