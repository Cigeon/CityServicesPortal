import { UserShort } from "../user/user-short";

export interface Review {
    id: string,
    text: string,
    created: string,
    user: UserShort
}