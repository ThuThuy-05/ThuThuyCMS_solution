import React, { useEffect, useState } from "react";
import { useParams, Link } from "react-router-dom";
import productService from "../../services/productService";
import ProductInfo from "./ProductInfo";

function ProductDetail() {

    const { id } = useParams();

    const [product, setProduct] = useState(null);
    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadProduct();
    }, [id]);

    const loadProduct = async () => {

        try {

            const data =
                await productService.getProductById(id);

            setProduct(data);

        }
        catch (error) {

            console.error(error);

        }
        finally {

            setLoading(false);

        }

    };

    if (loading) {
        return (
            <div className="container py-5 text-center">
                <div className="spinner-border text-primary"></div>
                <p className="mt-3">Đang tải sản phẩm...</p>
            </div>
        );
    }

    if (!product) {
        return (
            <div className="container py-5 text-center">
                <h3>Không tìm thấy sản phẩm</h3>
            </div>
        );
    }

    return (
        <div className="container py-5">

            {/* Breadcrumb */}
            <nav className="mb-4">

                <Link to="/" className="text-decoration-none">
                    Trang chủ
                </Link>

                <span className="mx-2">/</span>

                <Link to="/shop" className="text-decoration-none">
                    Cửa hàng
                </Link>

                <span className="mx-2">/</span>

                <span className="text-muted">
                    {product.name}
                </span>

            </nav>

            <ProductInfo product={product} />

        </div>
    );
}

export default ProductDetail;