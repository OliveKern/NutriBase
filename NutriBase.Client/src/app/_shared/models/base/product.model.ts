import { Material } from "../../enums/material.enum";
import { NutritionForm } from "../../enums/nutritionForm.enum";
import { Recipe, ShoppingList } from "../app/plan.model";

export class Product {
    definition: string;
    description: string;
    price: number;
    packageSize: string;
    recipes: Recipe[];
    shoppingLists: ShoppingList[];

    constructor(
        definition: string,
        description: string,
        price: number,
        packageSize: string,
        recipes: Recipe[],
        shoppingLists: ShoppingList[]) {
        this.definition = definition;
        this.description = description;
        this.price = price;
        this.packageSize = packageSize;
        this.recipes = recipes;
        this.shoppingLists = shoppingLists;
    }
}

export class Grocery extends Product {
    kaloriesPer100g: number;
    proteinPer100g: number;
    sugarPer100g: number;
    nutritionForm: NutritionForm;

    constructor(definition: string,
        description: string,
        price: number,
        packageSize: string,
        recipes: Recipe[],
        shoppingLists: ShoppingList[],
        kaloriesPer100g: number,
        proteinPer100g: number,
        sugarPer100g: number,
        nutritionForm: NutritionForm) {
        super(definition,
            description,
            price,
            packageSize,
            recipes,
            shoppingLists);
        this.kaloriesPer100g = kaloriesPer100g;
        this.proteinPer100g = proteinPer100g;
        this.sugarPer100g = sugarPer100g;
        this.nutritionForm = nutritionForm;
    }
}

export class HouseholdItem extends Product {
    material: Material;

    constructor(definition: string,
        description: string,
        price: number,
        packageSize: string,
        recipes: Recipe[],
        shoppingLists: ShoppingList[],
        material: Material) {
        super(definition,
            description,
            price,
            packageSize,
            recipes,
            shoppingLists);
        this.material = material;
    }
}