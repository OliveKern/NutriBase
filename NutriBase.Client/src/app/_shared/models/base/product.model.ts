import { Material } from "../../enums/material.enum";
import { NutritionForm } from "../../enums/nutritionForm.enum";

export interface Product {
    definition: string;
    description: string;
    price: number;
    packageSize: string;
}

export interface Grocery extends Product {
    kaloriesPer100g: number;
    proteinPer100g: number;
    sugarPer100g: number;
    nutritionForm: NutritionForm;
}

export interface HouseholdItem extends Product {
    material: Material;
}