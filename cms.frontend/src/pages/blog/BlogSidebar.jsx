import React, { useEffect, useState } from "react";
import categoryService from "../../services/categoryService";

function BlogSidebar({ onCategorySelect }) {

    const [categories, setCategories] = useState([]);

    useEffect(() => {
        loadCategories();
    }, []);

    const loadCategories = async () => {
        try {

            const data =
                await categoryService.getAllCategories();

            setCategories(data);

        }
        catch (error) {
            console.error(error);
        }
    };

    return (
        <div className="card shadow border-0">

            <div
                className="card-header text-white"
                style={{
                    background: "#005088"
                }}
            >
                <h5 className="mb-0">
                    Danh mục bài viết
                </h5>
            </div>

            <div className="list-group list-group-flush">

                <button
                    className="list-group-item list-group-item-action"
                    onClick={() => onCategorySelect(null)}
                >
                    📚 Tất cả bài viết
                </button>

                {categories.map((item) => (
                    <button
                        key={item.id}
                        className="list-group-item list-group-item-action"
                        onClick={() => onCategorySelect(item.id)}
                    >
                        📰 {item.name || item.title}
                    </button>
                ))}

            </div>

        </div>
    );
}

export default BlogSidebar;