using LeoLib.game.model.asset;
using LeoLib.game.texture;
using OpenTK.Mathematics;

namespace LeoLib
{
    /// <summary>
    /// Class Asset <br/>
    /// This class represents a generic asset that is to be rendered.  It <br/>
    /// contains the transform, mesh and behavior of the asset.  The <br/>
    /// textures that are associated with the asset are managed via a set <br/>
    /// of abstract functions that create, assign and the delete the texture <br/>
    /// when the asset is being destroyed.  
    /// </summary>
    public abstract class Asset
    {
        // Defines the transform of the asset (Rotation, Translate, Scale)
        private Transform transform = null;

        // Defines the rendering mesh
        private Mesh mesh = null;

        // Defines the behavior of an asset using a state mechine
        private Behavior behavior = null;

        /*******************/
        /*** Constructor ***/
        /*******************/

        public Asset(Mesh mesh) : this(mesh, null)
        {
        }

        public Asset(Mesh mesh, Behavior behavior)
        {
            this.transform = new Transform();
            this.mesh = mesh;

            Add(behavior);
        }

        /**************************/
        /*** Abstract Functions ***/
        /**************************/

        public abstract void AssignTextures();

        public abstract void DeleteTextures();

        public abstract void CreateTextures();

        /************************/
        /*** Public Functions ***/
        /************************/

        public void Update(float deltaTime)
        {
            if (behavior != null)
            {
                behavior.Update(deltaTime, transform);
            }
        }

        public void Add(Behavior behavior)
        {
            if (behavior != null)
            {
                this.behavior = behavior;
            }
        }

        /// <summary>
        /// Check() - Checks the behavior states of the current asset.  This <br/>
        /// function allows the asset to traverse from one state to another.  <br/>
        /// The "context" object contains the current context of the render <br/>
        /// loop.
        /// </summary>
        /// 
        /// <param name="context"></param>
        public void Check(EventContext context)
        {
            if (behavior != null) { 
                behavior.Check(context);
            }
        }

        /// <summary>
        /// Construct() - Builds the mesh that is associated with the asset.  <br/>
        /// This is done by setting up the vbo, vao and possible ebo.  <br/>
        /// This also includes the binding and unbinding of all buffers.
        /// </summary>
        public void Construct()
        {
            CreateTextures();
            mesh.Contruct();
        }

        public void Render()
        {
            AssignTextures();
            mesh.Render();
        }

        public void OnUnLoad()
        {
            mesh.OnUnLoad();
            DeleteTextures();
        }

        public Matrix4 GetModel()
        {
            return (transform.GetModel());
        }

        /***************************/
        /*** Protected Functions ***/
        /***************************/

        protected void AssetImageScale(TextureData data)
        {
            transform.Scale(1.0f, data.Scale(), 1.0f);
        }

        /*************************/
        /*** Private Functions ***/
        /*************************/

        /// <summary>
        /// BindVao() - Binds the VAO of the mesh.  This is used during the <br/>
        /// execution of the shader that is associated with the asset.  <br/>
        /// Only one shader can be associated with a asset.
        /// </summary>
        public void BindVao()
        {
            mesh.BindVao();
        }
    }
}
