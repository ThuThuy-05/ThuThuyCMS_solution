import axiosClient from "../api/axiosClient";

const categoryService = {

    getAllCategories: async () => {
        try {
            const response = await axiosClient.get("/Categories");

            return response.data || response;
        }
        catch (error) {
            console.error("Lỗi lấy danh mục:", error);
            throw error;
        }
    }

};

export default categoryService;