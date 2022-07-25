import { Video } from "./video"
import { VideoCategory } from "./video-category"

export interface Serie {
    id: number
    title: string
    banner: string
    author: string
    category: VideoCategory | null
    videos: Array<Video>
}