import React, { useState } from "react";

const IMAGE_BASE_URL = "https://localhost:7067";

function ProductInfo({ product }) {

    const [quantity, setQuantity] = useState(1);

    const formatCurrency = (value) => {

        return new Intl.NumberFormat("vi-VN", {
            style: "currency",
            currency: "VND"
        }).format(value);

    };

    return (

        <div className="row bg-white shadow rounded p-4">

            {/* Hình ảnh */}

            <div className="col-lg-5">

                <img
                    src={IMAGE_BASE_URL + product.imageUrl}
                    alt={product.name}
                    className="img-fluid rounded border"
                    style={{
                        width: "100%",
                        height: "500px",
                        objectFit: "cover"
                    }}
                />

            </div>

            {/* Thông tin */}

            <div className="col-lg-7">

                <h2 className="fw-bold mb-3">
                    {product.name}
                </h2>

                <div
                    className="p-3 rounded mb-4"
                    style={{
                        background: "#f8f9fa"
                    }}
                >

                    <h3 className="text-danger fw-bold mb-0">
                        {formatCurrency(product.price)}
                    </h3>

                </div>

                {/*<p className="text-muted">*/}
                {/*    Mã sản phẩm: #{product.id}*/}
                {/*</p>*/}

                <hr />

                <h5 className="mb-3">
                    Số lượng
                </h5>

                <div className="d-flex align-items-center mb-4">

                    <button
                        className="btn btn-outline-secondary"
                        onClick={() =>
                            quantity > 1 &&
                            setQuantity(quantity - 1)
                        }
                    >
                        -
                    </button>

                    <input
                        value={quantity}
                        readOnly
                        className="form-control text-center mx-2"
                        style={{
                            width: "80px"
                        }}
                    />

                    <button
                        className="btn btn-outline-secondary"
                        onClick={() =>
                            setQuantity(quantity + 1)
                        }
                    >
                        +
                    </button>

                </div>

                <div className="d-flex gap-3">

                    <button
                        className="btn btn-lg btn-outline-primary me-2"
                    >
                        <i className="fas fa-cart-plus me-2"></i>
                        Thêm vào giỏ
                    </button>

                    <button
                        className="btn btn-lg text-white"
                        style={{
                            backgroundColor: "#11CAA0"
                        }}
                    >
                        Mua ngay
                    </button>

                </div>

                <hr className="my-4" />

                <h5>Mô tả sản phẩm</h5>

                <p className="text-secondary">

                    Giày chạy bộ cao cấp, thiết kế hiện đại,
                    chất liệu thoáng khí, phù hợp chạy bộ,
                    tập gym và sử dụng hằng ngày.

                </p>

            </div>

        </div>

    );
}

export default ProductInfo;