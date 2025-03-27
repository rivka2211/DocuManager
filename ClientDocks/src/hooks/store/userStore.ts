import { makeAutoObservable } from "mobx";
import axios from "axios";
import { UserDTO } from "../types";

const MYAPI = "http://localhost:5299";

const apiClient = axios.create({
  baseURL: MYAPI,
});

class UserStore {
  user: UserDTO | null = null;
  token: string = sessionStorage.getItem("token") ?? "";
  loading: boolean = false;
  error: any = null;

  constructor() {
    makeAutoObservable(this);
    this.setAuthHeader(); 
  }

 
  setAuthHeader() {
    if (this.token) {
      apiClient.defaults.headers.common["Authorization"] = `Bearer ${this.token}`;
    } else {
      delete apiClient.defaults.headers.common["Authorization"];
    }
  }

  async login(name: string, password: string) {
    try {
      const response = await apiClient.post("/api/login", { name, password });
      this.token = response.data.token;
      sessionStorage.setItem("token", this.token);
      this.setAuthHeader(); 
      await this.loadUser();
    } catch (error) {
      this.handleError(error, "Login failed");
    }
  }

  async register(name: string, email: string, password: string) {
    try {
      const response = await apiClient.post("/api/register", { name, email, password });
      this.token = response.data.token;
      sessionStorage.setItem("token", this.token);
      this.setAuthHeader(); 
      await this.loadUser();
    } catch (error) {
      this.handleError(error, "Registration failed");
    }
  }

  async update(name: string, email: string, password: string) {
    try {
      await apiClient.put("/api/user", { name, email, password });
      await this.loadUser();
    } catch (error) {
      this.handleError(error, "Failed to update user");
    }
  }

  async loadUser() {
    if (!this.token) return;
    try {
      const response = await apiClient.get("/api/user");
      this.user = response.data;
    } catch (error) {
      this.handleError(error, "Failed to load user");
    }
    console.log("user", this.user);
  }

  logout() {
    this.user = null;
    this.token = "";
    sessionStorage.removeItem("token");
    this.setAuthHeader(); 
  }

  handleError(error: any, message: string) {
    if (axios.isAxiosError(error) && error.response) {
      this.error = error.response.data;
    } else {
      this.error = "An unknown error occurred";
    }
    console.error(message, error);
  }
}

export const userStore = new UserStore();
