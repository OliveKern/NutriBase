import { NutritionForm } from "../../enums/nutritionForm.enum";
import { Grocery, HouseholdItem } from "../base/product.model";

export class Plan {
    definition: string;
    modifiedDate: Date;
    groceries: Grocery[];
    householdItems: HouseholdItem[];
    userId: number;

    private _totalCost: number = 0;
    private _costAccurate: boolean = true;
    // private _groceryNumber: number = 0;
    // private _householdItemNumber: number = 0;

    constructor(
        definition: string = '',
        creationDate: Date = new Date(),
        groceries: Grocery[] = [],
        householdItems: HouseholdItem[] = [],
        // groceryNumber: number,
        // householdItemNumber: number,
        userId: number = 0) {
        this.definition = definition;
        this.modifiedDate = creationDate;
        this.groceries = groceries;
        this.householdItems = householdItems;
        this.userId = userId;
    }

    get totalCost(): number {
        if (!this.totalCost) {
            this._totalCost = [...this.groceries, ...this.householdItems].reduce((sum, item) => sum + item.price, 0);
        }
        return this._totalCost;
    }

    get costAccurate(): boolean {
        if (this._costAccurate) {
            this._costAccurate = this.groceries.every(g => g.price != null) && this.householdItems.every(h => h.price != null);
        }
        return this._costAccurate;
    }

    get groceryNumber(): number {
        // if (!this._groceryNumber) {
        //     this._groceryNumber = this.groceries.length;
        // }
        // return this._groceryNumber;
        return this.groceries.length;
    }

    get householdItemNumber(): number {
        // if (!this._householdItemNumber) {
        //     this._householdItemNumber = this.groceries.length;
        // }
        // return this._householdItemNumber;
        return this.householdItems.length; 
    }  

    addProduct(product: Grocery | HouseholdItem) {
        if (product instanceof Grocery) {
            this.groceries.push(product);
        } else {
            this.householdItems.push(product);
        }
    }
    removeProduct(product: Grocery | HouseholdItem) {
        if (product instanceof Grocery) {
            this.groceries = this.groceries.filter(g => g != product);
        } else {
            this.householdItems = this.householdItems.filter(h => h != product);
        }
    }
}

export class ShoppingList extends Plan {
    dueDate: Date | null;
    usage: string;

    constructor(
        definition: string,
        modifiedDate: Date,
        groceries: Grocery[],
        householdItems: HouseholdItem[],
        groceryNumber: number,
        householdItemNumber: number,
        userId: number,
        dueDate: Date | null = null,
        usage: string = ''
    ) {
        super(
            // definition,
            // modifiedDate,
            // groceries,
            // householdItems,
            // groceryNumber,
            // householdItemNumber,
            // userId
        );
        this.dueDate = dueDate ?? null;
        this.usage = usage;
    }
}

export class Recipe extends Plan {
    description: string;
    author: string;
    durationInMin: number;
    valuation: number;
    difficulty: number;
    nutritionForm: NutritionForm;

    constructor(
        definition: string,
        modifiedDate: Date,
        groceries: Grocery[],
        householdItems: HouseholdItem[],
        groceryNumber: number,
        householdItemNumber: number,
        userId: number,
        description: string = '',
        author: string = '',
        durationInMin: number = 0,
        valuation: number = 0,
        difficulty: number = 0,
        nutritionForm: NutritionForm = NutritionForm.NotSpecified
    ) {
        super(
            // definition,
            // modifiedDate,
            // groceries,
            // householdItems,
            // groceryNumber,
            // householdItemNumber,
            // userId
        );
        this.description = description;
        this.author = author;
        this.durationInMin = durationInMin;
        this.valuation = valuation;
        this.difficulty = difficulty;
        this.nutritionForm = nutritionForm;
    }
}
