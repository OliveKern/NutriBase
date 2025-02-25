import { NutritionForm } from "../../enums/nutritionForm.enum";
import { Grocery, HouseholdItem } from "../base/product.model";

export interface Plan {
    definition: string;
    totalCost: number;
    costAccurate: boolean;
    creationDate: Date;
    groceries: Grocery[];
    householdItems: HouseholdItem[];
    userId: number;
}

export interface ShoppingList extends Plan {
    usage: string;
    dueDate: Date;
    goodsNumber: number;
}

export interface Recipe extends Plan {
    description: string;
    author: string;
    durationInMin: number;
    valuation: number;
    difficulty: number;
    nutritionForm: NutritionForm;
    ingredientNumber: number;
}