import { createContext, Dispatch } from "react";


export type User = {
    id: number,
    firstName: string,
    lastName: string,
    email: string,
    password: string,
    address: string,
    phone: string
}

export const initialUser: User = {
    id: 0,
    firstName: "INITIAL",
    lastName: "initial",
    address: "",
    email: "",
    password: "",
    phone: ""
}

export type Action = {
    type: 'ADD' | 'REMOVE' | 'GET' | 'UPDATE',
    data: Partial<User>
}

export const UserReducer = (state: User, action: Action) => {

    switch (action.type) {
        case 'ADD':
           
            console.log(action.data);

            return { ...state, ...action.data }

        case 'UPDATE':
            return { ...state, ...action.data }


        default://get
            return state
    }
}
// הגדרת סוג קונטקסט
type UserContextType = [User, Dispatch<Action>];
//יצירת קונטקסט
export const UserContext = createContext<UserContextType>([initialUser, () => { }])