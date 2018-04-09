import { CategoryShort } from "../category/category-short";
import { UserShort } from "../user/user-short";
import { Review } from "../review/review";

export interface Petition {
    id: string,
    name: string,
    description: string,
    created: string,
    modified: string,
    status: number,
    category: CategoryShort,
    user: UserShort,
    voters: UserShort[],
    review: Review
}