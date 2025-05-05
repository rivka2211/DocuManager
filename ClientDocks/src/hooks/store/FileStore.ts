import { makeAutoObservable } from "mobx";
import {categoryStore} from "./CategoryStore";
import { FileCreateDTO, FileDTO } from "../types";
import { apiClient } from "./UserStore";


class FileStore {
  files:FileDTO[] = [];
  loading = false;
  categoryStore;

  constructor(categoryStore: any) {
    makeAutoObservable(this);
    this.categoryStore = categoryStore;
  }

  // שליפת קובץ לפי מזהה
  async getFileById(fileId: number) {
    this.loading = true;
    try {
      const response = await apiClient.get(`File/${fileId}`);
      return response.data;
    } catch (error) {
      console.error("Failed to fetch file:", error);
      return null;
    } finally {
      this.loading = false;
    }
  }

//   // שליפת כל קבצי המשתמש
//   async loadAllUserFiles() {
//     this.loading = true;
//     try {
//       const response = await apiClient.get(`File/user/all`);
//       this.files = response.data;
//     } catch (error) {
//       console.error("Failed to fetch user files:", error);
//     } finally {
//       this.loading = false;
//     }
//   }

//   // שליפת קבצי הפעילות של המשתמש
//   async loadUserActivityFiles() {
//     this.loading = true;
//     try {
//       const response = await apiClient.get(`File/user`);
//       this.files = response.data;
//     } catch (error) {
//       console.error("Failed to fetch user activity files:", error);
//     } finally {
//       this.loading = false;
//     }
//   }

  // שליפת קבצים לפי מזהה קטגוריה
  async loadFilesByCategoryId(categoryId: number) {
    this.loading = true;
    try {
      const response = await apiClient.get(`File/category/${categoryId}`);
      this.files = response.data;
    } catch (error) {
      console.error("Failed to fetch category files:", error);
    } finally {
      this.loading = false;
    }
  }

  // הוספת קובץ חדש
  async addFile(file:FileCreateDTO) {
    try {
      const response = await apiClient.post(`/api/File`, file);
      this.files.push(response.data);
    } catch (error) {
      console.error("Failed to add file:", error);
    }
  }

  // עדכון קובץ קיים
  async updateFile(fileId: number, fileUpdate: { name: string; categoryId: number }) {
    try {
      const response = await apiClient.put(`/api/File/${fileId}`, fileUpdate);
      const index = this.files.findIndex((file) => file.id === fileId);
      if (index !== -1) {
        this.files[index] = response.data;
      }
    } catch (error) {
      console.error("Failed to update file:", error);
    }
  }

  // מחיקה רכה של קובץ
  async softDeleteFile(fileId: number) {
    try {
      const response = await apiClient.patch(`File/${fileId}`);
      if (response.status === 204) {
        this.files = this.files.filter((file) => file.id !== fileId);
      }
    } catch (error) {
      console.error("Failed to soft delete file:", error);
    }
  }

  // מחיקת כל קבצי המשתמש
  async deleteUserFiles() {
    try {
      const response = await apiClient.patch(`File/user`);
      console.log(response.data); // הדפסת מספר הקבצים שנמחקו
      this.files = [];
    } catch (error) {
      console.error("Failed to delete user files:", error);
    }
  }
}

export const fileStore = new FileStore(categoryStore);
