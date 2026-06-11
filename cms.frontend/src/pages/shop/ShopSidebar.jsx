import React, { useState } from "react";

function ShopSidebar({ onFilter }) {
    const [minPrice, setMinPrice] = useState("");
    const [maxPrice, setMaxPrice] = useState("");

    const handleFilter = () => {
        if (typeof onFilter !== "function") return;

        onFilter({
            minPrice: minPrice ? Number(minPrice) : 0,
            maxPrice: maxPrice ? Number(maxPrice) : Infinity,
        });
    };

    const handleReset = () => {
        setMinPrice("");
        setMaxPrice("");

        if (typeof onFilter !== "function") return;

        // reset về mặc định (hiển thị tất cả)
        onFilter({
            minPrice: 0,
            maxPrice: Infinity,
        });
    };

    return (
        <div className="card shadow-sm border-0">

            <div className="card-header bg-primary text-white">
                <h5 className="mb-0">Bộ lọc sản phẩm</h5>
            </div>

            <div className="card-body">

                <div className="mb-3">
                    <label>Giá từ</label>
                    <input
                        type="number"
                        className="form-control"
                        value={minPrice}
                        onChange={(e) => setMinPrice(e.target.value)}
                    />
                </div>

                <div className="mb-3">
                    <label>Giá đến</label>
                    <input
                        type="number"
                        className="form-control"
                        value={maxPrice}
                        onChange={(e) => setMaxPrice(e.target.value)}
                    />
                </div>

                <button
                    className="btn btn-primary w-100 mb-2"
                    onClick={handleFilter}
                >
                    Lọc sản phẩm
                </button>

                <button
                    className="btn btn-outline-secondary w-100"
                    onClick={handleReset}
                >
                    Xóa lọc
                </button>

            </div>

        </div>
    );
}

export default ShopSidebar;