import { makeAutoObservable } from "mobx";
import axios from "axios";
import { FileDTO, UserDTO, UserUpdateDto, FileCreateDTO, UpdateFileNameDTO } from "../store/types";

const MYAPI="https://localhost:7175/api";

export class UserStore {
  user: UserDTO | null = null;
  files: FileDTO[] = [];
  loading: boolean = false;
  error: any = null;

  constructor() {
    makeAutoObservable(this);
    this.setupAxiosInterceptors();
  }

  setupAxiosInterceptors() {
    axios.interceptors.request.use(
      (config) => {
        const token = sessionStorage.getItem("token");
        if (token) {
          config.headers.Authorization = `Bearer ${token}`;
        }
        return config;
      },
      (error) => Promise.reject(error)
    );
  }

  async fetchUser(userId: number) {
    this.loading = true;
    try {
      const response = await axios.get<UserDTO>(`${MYAPI}/User/${userId}`);
      this.user = response.data;
      this.files = response.data.files || [];
    } catch (error) {
      this.error = error;
    } finally {
      this.loading = false;
    }
  }

  async updateUser(userId: number, userData: UserUpdateDto) {
    try {
      await axios.put(`${MYAPI}/User/${userId}`, userData);
      if (this.user) {
        this.user = { ...this.user, ...userData };
      }
    } catch (error) {
      this.error = error;
    }
  }

  async deleteUser(userId: number) {
    try {
      await axios.delete(`${MYAPI}/User/${userId}`);
      this.user = null;
      this.files = [];
    } catch (error) {
      this.error = error;
    }
  }

  async addFile(file: FileCreateDTO) {
    if (!this.user) return;
    try {
      const response = await axios.post<FileDTO>(`${MYAPI}/User/${this.user.id}/files`, file);
      this.files.push(response.data);
    } catch (error) {
      this.error = error;
    }
  }

  async deleteFile(fileId: number) {
    if (!this.user) return;
    try {
      await axios.delete(`${MYAPI}/User/${this.user.id}/files/${fileId}`);
      this.files = this.files.filter(file => file.id !== fileId);
    } catch (error) {
      this.error = error;
    }
  }

  async updateFileName(fileId: number, newName: string) {
    if (!this.user) return;
    try {
      await axios.patch(`${MYAPI}/User/${this.user.id}/files/${fileId}`, { name: newName } as UpdateFileNameDTO);
      this.files = this.files.map(file => file.id === fileId ? { ...file, fileName: newName } : file);
    } catch (error) {
      this.error = error;
    }
  }
}

// const userStore = new UserStore();
// export default userStore;
