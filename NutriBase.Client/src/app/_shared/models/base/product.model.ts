import { Material } from "../../enums/material.enum";
import { NutritionForm } from "../../enums/nutritionForm.enum";

export class Product {
  id?: number;
  definition: string;
  description: string;
  price: number;
  packageSize: string;

  constructor(
    definition: string,
    description: string,
    price: number,
    packageSize: string,
    id?: number,
  ) {
    this.id = id;
    this.definition = definition;
    this.description = description;
    this.price = price;
    this.packageSize = packageSize;
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
    kaloriesPer100g: number,
    proteinPer100g: number,
    sugarPer100g: number,
    nutritionForm: NutritionForm) {
    super(definition,
      description,
      price,
      packageSize);
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
    material: Material) {
    super(definition,
      description,
      price,
      packageSize);
    this.material = material;
  }
}
