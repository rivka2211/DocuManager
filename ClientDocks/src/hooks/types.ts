export type ActivityHistoryDTO = {
  id: number;
  userId?: number;
  timestamp: Date;
  files: FileUpdateDTO[];
};

export type CategoryDTO = {
  id: number;
  name: string;
  files: FileDTO[];
};

export type FileDTO = {
  id: number;
  fileName: string;
  fileUrl: string;
  uploadTime: Date;
  ownerId: number;
  content: string;
  categoryId: number;
  category: CategoryDTO;
  isDeleted: boolean;
};

export type FileCreateDTO = {
  fileName: string;
  fileUrl: string;
  ownerId: number;
  categoryId: number;
  isDeleted: boolean;
};

export type FileUpdateDTO = {
  fileName: string;
  categoryId: number;
};

export type UserDTO = {
  id: number;
  name: string;
  email: string;
  password: string;
  role: string;
  categories: CategoryDTO[];
  isDeleted: boolean;
};

export type UserUpdateDTO = {
  name: string;
  password: string;
  email: string;
};

export type UserHistoryDTO = {
  name: string;
  history: ActivityHistory[];
};

export type ActivityHistory = {
  // מבוסס על השימוש בתוך UserHistoryDTO
};
