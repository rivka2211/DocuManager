import { makeAutoObservable } from "mobx";
import { apiClient } from "./UserStore"; 
import { CategoryDTO } from "../types";

class CategoryStore {
    categories: CategoryDTO[] = [];
    selectedCategoryId: number | null = null;
    currentCategory: CategoryDTO | null = null;
    loading = false;

    constructor() {
        makeAutoObservable(this);
    }

    // שליפת קטגוריה לפי מזהה
    async getCategoryById(categoryId: number) {
        this.loading = true;
        try {
            const response = await apiClient.get(`category/${categoryId}`);
            this.currentCategory = response.data;
            return response.data;
        } catch (error) {
            console.error("Failed to fetch category:", error);
            return null;
        }finally{
            this.loading = false;
        }
    }

    // יצירת קטגוריה חדשה
    async addCategory(name: string) {
        try {
            const response = await apiClient.post(`category`, null, {
                params: { name }
            });
            this.categories.push(response.data);
            this.currentCategory = response.data;
            this.selectedCategoryId = response.data.id;
        } catch (error) {
            console.error("Failed to add category:", error);
        }
    }

    // עדכון קטגוריה קיימת
    async updateCategory(categoryId: number, categoryData: { name: string }) {
        try {
            await apiClient.put(`category/${categoryId}`, categoryData);
            const index = this.categories.findIndex((c) => c.id === categoryId);
            if (index !== -1) {
                this.categories[index] = { ...this.categories[index], ...categoryData };
            }
        } catch (error) {
            console.error("Failed to update category:", error);
        }
    }

    // מחיקת קטגוריה
    async deleteCategory(categoryId: number) {
        try {
            await apiClient.delete(`category/${categoryId}`);
            this.categories = this.categories.filter((c) => c.id !== categoryId);
        } catch (error) {
            console.error("Failed to delete category:", error);
        }
    }

    // שינוי הקטגוריה הנבחרת
    setSelectedCategory(categoryId: number | null) {
        this.selectedCategoryId = categoryId;
    }
}

export const categoryStore = new CategoryStore();

