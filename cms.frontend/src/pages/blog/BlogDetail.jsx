import React, { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import postService from "../../services/postService";

function BlogDetail() {

    const { id } = useParams();

    const [post, setPost] = useState(null);

    const [loading, setLoading] = useState(true);

    useEffect(() => {
        loadPost();
    }, [id]);

    const loadPost = async () => {
        try {
            const data = await postService.getPostById(id);
            setPost(data);
        } catch (error) {
            console.error(error);
        } finally {
            setLoading(false);
        }
    };

    if (loading) {
        return (
            <div className="container py-5 text-center">
                <h4>Đang tải bài viết...</h4>
            </div>
        );
    }

    if (!post) {
        return (
            <div className="container py-5 text-center">
                <h4>Không tìm thấy bài viết</h4>
            </div>
        );
    }

    return (
        <div className="container py-5">

            <h1 className="mb-3">
                {post.title}
            </h1>

            <p className="text-muted">
                {post.createdAt}
            </p>

            {post.imageUrl && (
                <img
                    src={`https://localhost:7218${post.imageUrl}`}
                    alt={post.title}
                    className="img-fluid rounded mb-4"
                />
            )}

            <div
                dangerouslySetInnerHTML={{
                    __html: post.content
                }}
            />

        </div>
    );
}

export default BlogDetail;